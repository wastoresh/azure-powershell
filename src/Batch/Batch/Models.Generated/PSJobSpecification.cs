﻿// -----------------------------------------------------------------------------
﻿//
﻿// Copyright Microsoft Corporation
﻿// Licensed under the Apache License, Version 2.0 (the "License");
﻿// you may not use this file except in compliance with the License.
﻿// You may obtain a copy of the License at
﻿// http://www.apache.org/licenses/LICENSE-2.0
﻿// Unless required by applicable law or agreed to in writing, software
﻿// distributed under the License is distributed on an "AS IS" BASIS,
﻿// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
﻿// See the License for the specific language governing permissions and
﻿// limitations under the License.
﻿// -----------------------------------------------------------------------------
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:5.0.17
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Batch.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.Azure.Batch;
    
    
    public partial class PSJobSpecification
    {
        
        internal Microsoft.Azure.Batch.JobSpecification omObject;
        
        private IDictionary commonEnvironmentSettings;
        
        private PSJobConstraints constraints;
        
        private PSJobManagerTask jobManagerTask;
        
        private PSJobPreparationTask jobPreparationTask;
        
        private PSJobReleaseTask jobReleaseTask;
        
        private IDictionary metadata;
        
        private PSJobNetworkConfiguration networkConfiguration;
        
        private PSPoolInformation poolInformation;
        
        public PSJobSpecification()
        {
            this.omObject = new Microsoft.Azure.Batch.JobSpecification();
        }
        
        public PSJobSpecification(PSPoolInformation poolInformation)
        {
            this.omObject = new Microsoft.Azure.Batch.JobSpecification(poolInformation.omObject);
        }
        
        internal PSJobSpecification(Microsoft.Azure.Batch.JobSpecification omObject)
        {
            if ((omObject == null))
            {
                throw new System.ArgumentNullException("omObject");
            }
            this.omObject = omObject;
        }
        
        public System.Boolean? AllowTaskPreemption
        {
            get
            {
                return this.omObject.AllowTaskPreemption;
            }
            set
            {
                this.omObject.AllowTaskPreemption = value;
            }
        }
        
        public IDictionary CommonEnvironmentSettings
        {
            get
            {
                if (((this.commonEnvironmentSettings == null) 
                            && (this.omObject.CommonEnvironmentSettings != null)))
                {
                    Dictionary<string, string> dict;
                    dict = new Dictionary<string, string>();
                    IEnumerator<Microsoft.Azure.Batch.EnvironmentSetting> enumerator;
                    enumerator = this.omObject.CommonEnvironmentSettings.GetEnumerator();
                    for (
                    ; enumerator.MoveNext(); 
                    )
                    {
                        dict.Add(enumerator.Current.Name, enumerator.Current.Value);
                    }
                    this.commonEnvironmentSettings = dict;
                }
                return this.commonEnvironmentSettings;
            }
            set
            {
                if ((value == null))
                {
                    this.omObject.CommonEnvironmentSettings = null;
                }
                else
                {
                    this.omObject.CommonEnvironmentSettings = new List<Microsoft.Azure.Batch.EnvironmentSetting>();
                }
                this.commonEnvironmentSettings = value;
            }
        }
        
        public PSJobConstraints Constraints
        {
            get
            {
                if (((this.constraints == null) 
                            && (this.omObject.Constraints != null)))
                {
                    this.constraints = new PSJobConstraints(this.omObject.Constraints);
                }
                return this.constraints;
            }
            set
            {
                if ((value == null))
                {
                    this.omObject.Constraints = null;
                }
                else
                {
                    this.omObject.Constraints = value.omObject;
                }
                this.constraints = value;
            }
        }
        
        public string DisplayName
        {
            get
            {
                return this.omObject.DisplayName;
            }
            set
            {
                this.omObject.DisplayName = value;
            }
        }
        
        public PSJobManagerTask JobManagerTask
        {
            get
            {
                if (((this.jobManagerTask == null) 
                            && (this.omObject.JobManagerTask != null)))
                {
                    this.jobManagerTask = new PSJobManagerTask(this.omObject.JobManagerTask);
                }
                return this.jobManagerTask;
            }
            set
            {
                if ((value == null))
                {
                    this.omObject.JobManagerTask = null;
                }
                else
                {
                    this.omObject.JobManagerTask = value.omObject;
                }
                this.jobManagerTask = value;
            }
        }
        
        public PSJobPreparationTask JobPreparationTask
        {
            get
            {
                if (((this.jobPreparationTask == null) 
                            && (this.omObject.JobPreparationTask != null)))
                {
                    this.jobPreparationTask = new PSJobPreparationTask(this.omObject.JobPreparationTask);
                }
                return this.jobPreparationTask;
            }
            set
            {
                if ((value == null))
                {
                    this.omObject.JobPreparationTask = null;
                }
                else
                {
                    this.omObject.JobPreparationTask = value.omObject;
                }
                this.jobPreparationTask = value;
            }
        }
        
        public PSJobReleaseTask JobReleaseTask
        {
            get
            {
                if (((this.jobReleaseTask == null) 
                            && (this.omObject.JobReleaseTask != null)))
                {
                    this.jobReleaseTask = new PSJobReleaseTask(this.omObject.JobReleaseTask);
                }
                return this.jobReleaseTask;
            }
            set
            {
                if ((value == null))
                {
                    this.omObject.JobReleaseTask = null;
                }
                else
                {
                    this.omObject.JobReleaseTask = value.omObject;
                }
                this.jobReleaseTask = value;
            }
        }
        
        public System.Int32? MaxParallelTasks
        {
            get
            {
                return this.omObject.MaxParallelTasks;
            }
            set
            {
                this.omObject.MaxParallelTasks = value;
            }
        }
        
        public IDictionary Metadata
        {
            get
            {
                if (((this.metadata == null) 
                            && (this.omObject.Metadata != null)))
                {
                    Dictionary<string, string> dict;
                    dict = new Dictionary<string, string>();
                    IEnumerator<Microsoft.Azure.Batch.MetadataItem> enumerator;
                    enumerator = this.omObject.Metadata.GetEnumerator();
                    for (
                    ; enumerator.MoveNext(); 
                    )
                    {
                        dict.Add(enumerator.Current.Name, enumerator.Current.Value);
                    }
                    this.metadata = dict;
                }
                return this.metadata;
            }
            set
            {
                if ((value == null))
                {
                    this.omObject.Metadata = null;
                }
                else
                {
                    this.omObject.Metadata = new List<Microsoft.Azure.Batch.MetadataItem>();
                }
                this.metadata = value;
            }
        }
        
        public PSJobNetworkConfiguration NetworkConfiguration
        {
            get
            {
                if (((this.networkConfiguration == null) 
                            && (this.omObject.NetworkConfiguration != null)))
                {
                    this.networkConfiguration = new PSJobNetworkConfiguration(this.omObject.NetworkConfiguration);
                }
                return this.networkConfiguration;
            }
            set
            {
                if ((value == null))
                {
                    this.omObject.NetworkConfiguration = null;
                }
                else
                {
                    this.omObject.NetworkConfiguration = value.omObject;
                }
                this.networkConfiguration = value;
            }
        }
        
        public Microsoft.Azure.Batch.Common.OnAllTasksComplete? OnAllTasksComplete
        {
            get
            {
                return this.omObject.OnAllTasksComplete;
            }
            set
            {
                this.omObject.OnAllTasksComplete = value;
            }
        }
        
        public Microsoft.Azure.Batch.Common.OnTaskFailure? OnTaskFailure
        {
            get
            {
                return this.omObject.OnTaskFailure;
            }
            set
            {
                this.omObject.OnTaskFailure = value;
            }
        }
        
        public PSPoolInformation PoolInformation
        {
            get
            {
                if (((this.poolInformation == null) 
                            && (this.omObject.PoolInformation != null)))
                {
                    this.poolInformation = new PSPoolInformation(this.omObject.PoolInformation);
                }
                return this.poolInformation;
            }
            set
            {
                if ((value == null))
                {
                    this.omObject.PoolInformation = null;
                }
                else
                {
                    this.omObject.PoolInformation = value.omObject;
                }
                this.poolInformation = value;
            }
        }
        
        public System.Int32? Priority
        {
            get
            {
                return this.omObject.Priority;
            }
            set
            {
                this.omObject.Priority = value;
            }
        }
        
        public System.Boolean? UsesTaskDependencies
        {
            get
            {
                return this.omObject.UsesTaskDependencies;
            }
            set
            {
                this.omObject.UsesTaskDependencies = value;
            }
        }
    }
}
